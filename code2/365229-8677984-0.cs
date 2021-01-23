        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
    
    namespace ConsoleApplication3
    {
        public interface IABInterface
        {
            //Could be your SqlParameters
            string[] Params { get; }
        }
    
        public partial class IARequestDetails
        {
            public int One
            {
                get; set; 
            }
    
            public int Two
            {
                get;set;
            }
        }
    
        public partial class ClassA : IARequestDetails
        {
            public int IsUrgent 
            {
                get;set;
            }
        }
    
        public partial class ClassB : IARequestDetails
        {
            public int BudgetCode
            {
                get;
                set;
            }
    
            public int IsUrgent
            {
                get;
                set;
            }
        }
    
        public partial class ClassA : IABInterface
        {
            #region IABInterface Members
    
            public string[] Params
            {
                //Create your list of parameters
                get { return null; }
            }
    
            #endregion
        }
    
        public partial class ClassB : IABInterface
        {
            #region IABInterface Members
    
            public string[] Params
            {
                get
                {
                    return null;
                }
            }
            #endregion
        }
    
        public class Persist
        {
            public void Save<T>(T obj)
                where T : IARequestDetails, IABInterface
            {
                //Do you saving here ... 
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Persist persist = new Persist();
    
                persist.Save(new ClassA());
                persist.Save(new ClassB());
            }
        }
    }
