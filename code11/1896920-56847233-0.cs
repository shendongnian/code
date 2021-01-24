    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Model
    {
        private string mCounter;
        private string mName;
        private string mEmail;
        public Model(string mCounter,string mName,string mEmail)
        {
            this.mCounter = mCounter;
            this.mName = mName;
            this.mEmail = mEmail;
        }
        public string MCounter
        {
            get { return mCounter; }
        }
        public string MName
        {
            get { return mName; }
        }
        public string MEmail
        {
            get { return mEmail; }
        }
        # This method will output the results you need for each Model object.
        public override string ToString()
        {
            return MName + " <" + MEmail + ">";
        }
    }
                        
    public class Program
    {
        public static void Main()
        {
            List<Model> listModel = new List<Model>();
            listModel.Add(new Model("Counter 1", "Name 1", "email1@example.com"));
            listModel.Add(new Model("Counter 2", "Name 2", "email2@example.com"));
            
            string combined = string.Join( "; ", listModel.Select(c=>c.ToString()).ToArray<string>());
            Console.WriteLine(combined);
        }
    }
