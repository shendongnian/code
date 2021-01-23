    public static testhelper SpecialPrice(decimal w,decimal p)
    {
    //set your values in the object 
    var Obj=new testhelper{
    w=some value,
    p= some value 
    };
    //// your code 
      if (w < p)
     {
       return p;
     }else if(w > p && p>0){
       //return (w , p);
     }else{
       return w;
