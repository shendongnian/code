    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Diagnostics;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Linq;
    using System.Threading;
    
    namespace EfCore3Test
    {
    
        class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    
        class Db : DbContext
        {
    
            string constr;
            private static QueryResultsCache cache { get; } =  new QueryResultsCache();
            private QueryResultsCache Cache { get; } = cache;
    
            public IList<T> CacheQueryResults<T>(IQueryable<T> query)
            {
                return Cache.ReadThrough(query);
            }
            public Db() : this("server=.;database=EfCore3Test;Integrated Security=true")
            { }
    
            public Db(string constr)
            {
                this.constr = constr;
            }
            static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => 
                   {
                       builder.AddFilter((category, level) =>
                          category == DbLoggerCategory.Database.Command.Name
                          && level == LogLevel.Information).AddConsole();
                   }
                   );
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(constr, a => a.UseRelationalNulls(true));
                optionsBuilder.AddInterceptors(cache);
    
                optionsBuilder.UseLoggerFactory(loggerFactory);
                base.OnConfiguring(optionsBuilder);
            }
            public DbSet<Customer> Customers { get; set; }
        }
    
        public class QueryResultsCache : DbCommandInterceptor
        {
            class CacheEntry
            {
                public CacheEntry(DataTable dt)
                {
                    this.Data = dt;
                    this.LastRefresh = DateTime.Now;
                }
                public DateTime LastRefresh { get; set; }
                public DataTable Data { get; set; }
            }
    
            private ConcurrentDictionary<string, CacheEntry> resultCache = new ConcurrentDictionary<string, CacheEntry>();
    
            AsyncLocal<bool> cacheEntry = new AsyncLocal<bool>();
            public IList<T> ReadThrough<T>(IQueryable<T> query)
            {
                cacheEntry.Value = true;
                var results = query.ToList();
                cacheEntry.Value = false;
                return results;
            }
            public override InterceptionResult<DbDataReader> ReaderExecuting(
              DbCommand command,
              CommandEventData eventData,
              InterceptionResult<DbDataReader> result)
            {
                if (resultCache.ContainsKey(command.CommandText))
                {
                    Console.WriteLine("Query Result from Cache");
                    return InterceptionResult<DbDataReader>.SuppressWithResult(resultCache[command.CommandText].Data.CreateDataReader());
                }
                
                if (cacheEntry.Value)
                {
                    using (var rdr = command.ExecuteReader())
                    {
                        var dt = new DataTable();
                        dt.Load(rdr);
                        resultCache.AddOrUpdate(command.CommandText, s => new CacheEntry(dt), (s, d) => d);
                        Console.WriteLine("Cached Result Created");
                        return InterceptionResult<DbDataReader>.SuppressWithResult(dt.CreateDataReader());
                    }
                }
    
                return result;
            }
        }
        class Program
        {
    
            static void Main(string[] args)
            {
                using var db = new Db();
                db.Database.EnsureCreated();
    
                var c = db.CacheQueryResults( db.Customers );
    
                for (int i = 0; i < 1000; i++)
                {
                    var c2 = db.Customers.ToList();
                }
                
    
                Console.WriteLine(c);
    
    
            }
        }
    }
