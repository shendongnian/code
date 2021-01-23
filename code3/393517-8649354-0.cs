    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication3
    {
    
        public class MemberStatus : IDefault<MemberStatus>
        {
            public int StatusId { get; set; }
            public string Name { get; set; }
    
            public MemberStatus Default
            {
                get { return new MemberStatus() { StatusId = 0, Name = "All" }; }
            }
    
            public string IdName
            {
                get { return "StatusId"; }
            }
        }
    
        public class MemberTeam : IDefault<MemberTeam>
        {
            public int TeamId { get; set; }
            public string Name { get; set; }
    
            public MemberTeam Default
            {
                get { return new MemberTeam() { TeamId = 0, Name = "All" }; }
            }
    
            public string IdName
            {
                get { return "TeamId"; }
            }
        }
    
        public interface IDefault<T>
        {
            T Default { get; }
            string IdName { get; }
        }
    
        public interface IRepository<T>
        {
            IEnumerable<T> All();
        }
    
        public class MemberStatusRepository : IRepository<MemberStatus>
        {
            public IEnumerable<MemberStatus> All()
            {
                return new[] { 
                    new MemberStatus(),
                    new MemberStatus()
                };
            }
        }
        public class MemberTeamRepository : IRepository<MemberTeam>
        {
            public IEnumerable<MemberTeam> All()
            {
                return new[] { 
                    new MemberTeam(),
                    new MemberTeam()
                };
            }
        }
    
        public class DataAccessLayer
        {
            IRepository<MemberStatus> _memberStatusRepository;
            IRepository<MemberTeam> _memberTeamRepository;
            public DataAccessLayer()
            {
                _memberStatusRepository = new MemberStatusRepository();
                _memberTeamRepository = new MemberTeamRepository();
            }
    
    
            public SelectList<TResult> GetTeamSelectList<TRepository, TResult>(TRepository repo, int selectedTeamId)
                where TRepository : IRepository<TResult>
                where TResult : IDefault<TResult>, new()
            {
                List<TResult> teamList = repo.All().ToList();
                var dummyobj = new TResult();
                teamList.Insert(0, dummyobj.Default);
                var teamSelectList = new SelectList<TResult>(teamList, dummyobj.IdName, "Name", selectedTeamId);
                return teamSelectList;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var dal = new DataAccessLayer();
                SelectList<MemberStatus> results = dal.GetTeamSelectList<IRepository<MemberStatus>, MemberStatus>(new MemberStatusRepository(), 5);
                Console.WriteLine();
                Console.Read();
            }
        }
    
        public class SelectList<TResult>
        {
            public SelectList(List<TResult> teamList, string p, string p_2, int selectedTeamId)
            {
    
            }
        }
    
    }
