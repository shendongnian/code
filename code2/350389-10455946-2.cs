    public class Album
    {
        public int AlbumId { get; set; }
        public int GenreId { get; set; }
        public int ArtistId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string AlbumArtUrl { get; set; }
        public Genre Genre { get; set; }
        public Artist Artist { get; set; }
    }
    using System.Data.Entity.ModelConfiguration.Configuration;
    namespace MvcMusicStore.Models
    {
       public interface IEntityConfiguration
       {
           void AddConfiguration(ConfigurationRegistrar registrar);
       }
    }
    using System.ComponentModel.Composition;
    using System.Data.Entity.ModelConfiguration;
    using System.Data.Entity.ModelConfiguration.Configuration;
    namespace MvcMusicStore.Models.TypeConfig
    {
      [Export(typeof(IEntityConfiguration))]
      public class AlbumTypeConfiguration : EntityTypeConfiguration<Album>, IEntityConfiguration
      {
        public AlbumTypeConfiguration()
        {
            ToTable("Album");
        }
        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
      }
    }
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    namespace MvcMusicStore.Models
    {
      public class ContextConfiguration
      {
          [ImportMany(typeof(IEntityConfiguration))]
          public IEnumerable<IEntityConfiguration> Configurations { get; set; }
      }
    }
     using System;
     using System.ComponentModel.Composition.Hosting;
     using System.Data.Entity;
     using System.Data.Entity.ModelConfiguration;
     using System.Data.Entity.ModelConfiguration.Configuration;
     using System.Linq;
     using System.Reflection;
     namespace MvcMusicStore.Models
     {
       public class MusicStoreEntities : DbContext
       {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var container = new CompositionContainer(catalog);
            var exports = container.GetExportedValues<IEntityConfiguration>();
            foreach (var entityConfiguration in exports)
            {
                entityConfiguration.AddConfiguration(modelBuilder.Configurations);
            }    
            base.OnModelCreating(modelBuilder);
        }
      }
    }
