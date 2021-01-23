       public  MyData CreateMyData(double? value1, double? value2, double? value3)
        {
            var ss= typeof(MyData).GetConstructor(new Type[]{typeof(double),typeof(double),typeof(double)});
            var parametesr = ss.GetParameters();
            return new MyData(value1 ?? Convert.ToDouble(parametesr[0].DefaultValue), value2 ?? Convert.ToDouble(parametesr[1].DefaultValue), value3 ?? Convert.ToDouble(parametesr[2].DefaultValue)); 
        }
