    class EmirateRefactored
    {
        public List<RecipeDosings> resipeDosings = new List<RecipeDosings>();
        private Dictionary<string, Func<RecipeDosings, int>> m_objActionMapping;
        public EmirateRefactored()
        {
            m_objActionMapping = new Dictionary<string, Func<RecipeDosings, int>>();
            m_objActionMapping.Add("Bunker 1", bunker1);
            m_objActionMapping.Add("Bunker 2", bunker2);
            //etc
        }
        public void Process(ModBusMaster modbus_master)
        {
            foreach (RecipeDosings rd in resipeDosings)
            {
                if (m_objActionMapping.ContainsKey(rd.Bunker))
                {
                    int result = m_objActionMapping[rd.Bunker].Invoke(rd);
                    modbus_master.SetValue(result);
                }
                else
                    throw new ApplicationException("Couldn't parse bunker!");
            }
        }
        /// <summary>
        /// I have no idea what this is as it's not included in the sample code!
        /// </summary>
        public class ModBusMaster
        {
            public void SetValue(int i_intInput) { }
        }
        /// <summary>
        /// Some code relevant to "bunker 1"
        /// </summary>
        private int bunker1(RecipeDosings i_objRecipe)
        {
            return Convert.ToInt32(i_objRecipe.Massa) * 10;
        }
        /// <summary>
        /// Some code relevant to "bunker 2"
        /// </summary>
        private int bunker2(RecipeDosings i_objRecipe)
        {
            //bunker2 code
            return Convert.ToInt32(i_objRecipe.Massa) * 10;
        }
    }
