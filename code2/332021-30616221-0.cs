    using System.Data.Entity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    #region example2
    public class UserTest
    {
        public int UserTestID { get; set; }
        public string UserTestname { get; set; }
        public string Password { get; set; }
        public ICollection<UserTestEmailTest> UserTestEmailTests { get; set; }
        public static void DoSomeTest(ApplicationDbContext context)
        {
            for (int i = 0; i < 5; i++)
            {
                var user = context.UserTest.Add(new UserTest() { UserTestname = "Test" + i });
                var address = context.EmailTest.Add(new EmailTest() { Address = "address@" + i });
            }
            context.SaveChanges();
            foreach (var user in context.UserTest.Include(t => t.UserTestEmailTests))
            {
                foreach (var address in context.EmailTest)
                {
                    user.UserTestEmailTests.Add(new UserTestEmailTest() { UserTest = user, EmailTest = address, n1 = user.UserTestID, n2 = address.EmailTestID });
                }
            }
            context.SaveChanges();
        }
    }
    public class EmailTest
    {
        public int EmailTestID { get; set; }
        public string Address { get; set; }
        public ICollection<UserTestEmailTest> UserTestEmailTests { get; set; }
    }
    public class UserTestEmailTest
    {
        public int UserTestID { get; set; }
        public UserTest UserTest { get; set; }
        public int EmailTestID { get; set; }
        public EmailTest EmailTest { get; set; }
        public int n1 { get; set; }
        public int n2 { get; set; }
        internal static void RelateFluent(System.Data.Entity.DbModelBuilder builder)
        {
            // Primary keys
            builder.Entity<UserTest>().HasKey(q => q.UserTestID);
            builder.Entity<EmailTest>().HasKey(q => q.EmailTestID);
            builder.Entity<UserTestEmailTest>().HasKey(q =>
                new
                {
                    q.UserTestID,
                    q.EmailTestID
                });
            // Relationships
            builder.Entity<UserTestEmailTest>()
                .HasRequired(t => t.EmailTest)
                .WithMany(t => t.UserTestEmailTests)
                .HasForeignKey(t => t.EmailTestID);
            builder.Entity<UserTestEmailTest>()
                .HasRequired(t => t.UserTest)
                .WithMany(t => t.UserTestEmailTests)
                .HasForeignKey(t => t.UserTestID);
        }
    }
    #endregion
