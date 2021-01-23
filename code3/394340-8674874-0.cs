    List<Int16[]> lol=new List<Int16[]>();
    byte [] b=System.Text.Encoding.Default.GetBytes("lolololololololololololoolol");
    Int16 [] a=new Int16 [b.Length];
    for (Int32 i=0;i<a.Length;++i) {
        a[i]=Convert.ToInt16(b[i]);
    }
    lol.Add(a);
