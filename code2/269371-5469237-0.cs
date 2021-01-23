        public void Test(int SomeCondition,Object Param)
        {
            dynamic list;
            switch (SomeCondition)
            {
                case 0:
                    list = (List<int>)Param;
                    MessageBox.Show(list[0].ToString());
                    break;
                case 1:
                    list = (List<string>)Param;
                    MessageBox.Show(list[0].ToString());
                    break;
                default:
                    MessageBox.Show("Default!");
                    break;
            }
        }
