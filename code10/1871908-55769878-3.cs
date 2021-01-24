    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace WpfApplication2
    {
    public class Model
    {
        private IList<string> _comboItems;
        public IList<string> ComboItems
        {
            get { return _comboItems; }
            set { _comboItems = value; }
        }
    }
    }
 
  
