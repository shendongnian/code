    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    
    
    public class testMain : ICloneable
    {
    
        private string m_TestProp;
    
        private List<Record> m_Items = new List<Record>();
        public string TestProp
        {
            get { return m_TestProp; }
            set { m_TestProp = value; }
        }
    
        public List<Record> Items
        {
            get { return m_Items; }
        }
    
    
        public object Clone()
        {
    
            testMain cpy =(testMain) this.MemberwiseClone();
            
            foreach (Record rec in this.Items)
            {
                Record recCpy = (Record)rec.Clone();
                cpy.Items.Add(recCpy);
            }
    
            return cpy;
        }
    
    }
    
    public class Record : ICloneable
    {
    
        private string m_TestProp;
    
        public string TestProp
        {
            get { return m_TestProp; }
            set { m_TestProp = value; }
        }
    
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
