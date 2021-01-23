    using System;
    using Abp.Domain.Entities;
    using System.ComponentModel.DataAnnotations.Schema;
    namespace Discovery.History
    {
        [Table("HistoryRecords")]
        public class HistoryRecord : Entity<int>
        {
            public int ResearcherCount { get; set; }
            public DateTime DateSubmitted { get; set; }
            public string Comments { get; set; }
        }
    }
