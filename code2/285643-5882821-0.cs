    string prop1 = "";
    string prop2 = "";
    foreach (object item in myArray)
    {
       if (item is ObjType1)
       {
          prop1 = (item as ObjType1).FirstProp;
          prop2 = (item as ObjType1).SecondProp;
       }
       else if (item is ObjType2)
       {
          prop1 = (item as ObjType2).FirstProp;
          prop2 = (item as ObjType2).SecondProp;
       }
       else if (item is ObjType3)
       {
          (item as ObjType3).FirstProp = prop1;
          (item as ObjType3).SecondProp = prop2;
       }
    }
