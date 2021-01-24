    public class Object {
        string _name;
        int sizeX;
        int sizeY;
        int locationX;
        int locationY;
  
        public Object(string name) {
             locationX = 0;
             locationY = 0;
             switch(name) {
                case "chair":
                    _name = name;
                    sizeX = 50; //Predifined width of the chair object
                    sizeY = 70; //Predifined height of the chair object
                case ... //Continue with the process
             }
        }
        
        public void setLocation(int x, int y) {
            locationX = x;
            locationY = y;
        }
    }
