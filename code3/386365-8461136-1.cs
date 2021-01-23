            MyObject oObject = new MyObject();
            oObject.TheListOfObject1.Add(new Object1(1));
            oObject.TheListOfObject2.Add(new Object2(2));
            oObject.Prop1 = 3;
            string sJSON = oObject.ToJson();
            System.Diagnostics.Debug.WriteLine(sJSON);
            oObject = MyObject.FromJson(sJSON);
            System.Diagnostics.Debug.WriteLine(oObject.Prop1);
