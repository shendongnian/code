    public class Parent {
            private int child1 = 0;
            private int child2 = 0;
            public int iChild1 {
                get {
                    return child1; 
                }
                set {
                    child1 = value;
                }
            }
            public int iChild2 {
                get {
                    return child2;
                }
                set {
                    child2 = value;
                }
            }
            public void MainMethod() { 
                MySetProperty("iChild1",1);
                MySetProperty("iChild2",2);
                string strOutput = String.Format("iChild1 = {0} iChild2 = {1}",MyGetPrperty("iChild1"), MyGetPrperty("iChild2"));
            }
            public object MyGetProperty(string strPropName)
            {
                Type myType = typeof(Parent);
                PropertyInfo myPropInfo = myType.GetProperty(strPropName);
                return myPropInfo.GetValue(this, null);
            }
            public void MySetProperty(string strPropName, object value)
            {
                Type myType = typeof(Parent);
                PropertyInfo myPropInfo = myType.GetProperty(strPropName);
                myPropInfo.SetValue(this, value, null);
            }
        }
