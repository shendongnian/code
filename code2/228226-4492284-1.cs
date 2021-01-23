    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Test.Api;
    using Test.Api.Classes;
    using Test.Api.Interfaces;
    using Test.Api.Models;
    namespace Test.Api.Interfaces
    {
        public interface ITable
        {
            int Id { get; set; }
            string Name { get; set; }
        }
    }
    namespace Test.Api.Models
    {
        public class MemberTable : ITable
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class TableWithRelations
        {
            public MemberTable Member { get; set; }
            // list to contain partnered tables
            public IList<ITable> Partner { get; set; }
            public TableWithRelations()
            {
                Member = new MemberTable();
                Partner = new List<ITable>();
            }
        }
    }
    namespace Test.Api.Classes
    {
        public class MyClass
        {
            private IList<TableWithRelations> _tables;
            public MyClass()
            {
                _tables = new List<TableWithRelations>();
                // tableA stuff
                var tableA = new TableWithRelations { Member = { Id = 1, Name = "A" } };
                var relatedclasses = new List<ITable>
                 {
                    new MemberTable
                    {
                       Id = 2,
                       Name = "B"
                    }
                 };
                tableA.Partner = relatedclasses;
                _tables.Add(tableA);
                // tableB stuff
                var tableB = new TableWithRelations { Member = { Id = 2, Name = "B" } };
                relatedclasses = new List<ITable>
                 {
                    new MemberTable
                    {
                       Id = 3,
                       Name = "C"
                    }
                 };
                tableB.Partner = relatedclasses;
                _tables.Add(tableB);
                // tableC stuff
                var tableC = new TableWithRelations { Member = { Id = 3, Name = "C" } };
                relatedclasses = new List<ITable>
                 {
                    new MemberTable
                    {
                       Id = 2,
                       Name = "D"
                    }
                 };
                tableC.Partner = relatedclasses;
                _tables.Add(tableC);
                // tableD stuff
                var tableD = new TableWithRelations { Member = { Id = 3, Name = "D" } };
                relatedclasses = new List<ITable>
                 {
                    new MemberTable
                    {
                       Id = 1,
                       Name = "A"
                    },
                    new MemberTable
                    {
                       Id = 2,
                       Name = "B"
                    },
                 };
                tableD.Partner = relatedclasses;
                _tables.Add(tableD);
            }
            public IList<ITable> Compare(int tableId, string tableName)
            {
                return _tables.Where(table => table.Member.Id == tableId 
                                && table.Member.Name == tableName)
                            .SelectMany(table => table.Partner).ToList();
            }
        }
    }
    namespace Test.Api
    {
        public class TestClass
        {
            private MyClass _myclass;
            private IList<ITable> _relatedMembers;
            public IList<ITable> RelatedMembers
            {
                get { return _relatedMembers; }
            }
            public TestClass(int id, string name)
            {
                this._myclass = new MyClass();
                // the Compare method would take your two paramters
                // and return a mathcing set of related tables that formed the related tables
                _relatedMembers = _myclass.Compare(id, name); 
                // now do something wityh the resulting list
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // change these values to suit, along with rules in MyClass
            var id = 3;
            var name = "D";
            var testClass = new TestClass(id, name);
            Console.Write(string.Format("For Table{0} on Id{1}\r\n", name, id));
            Console.Write("----------------------\r\n");
            foreach (var relatedTable in testClass.RelatedMembers)
            {
                Console.Write(string.Format("Related Table{0} on Id{1}\r\n", relatedTable.Name, relatedTable.Id)); 
            }
            Console.Read();
        }
    }
