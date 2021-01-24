    class Item // please find a better name
    {
       public double Height {get;}
       public double MidSection {get;}
       public double Curve {get;}
    
       public Item( double height, double mid )
       {
           // TODO add Sanity Checks
           Height = height;
           MidSection = mid;
           Curve = height - mid / 2;
       }
    }
