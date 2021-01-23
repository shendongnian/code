    public class Consume {
        public void Example() {
            CustomControl ctrl = new CustomControl();
    
            // store {the act of setting this property of this object to a string}
            ctrl.SetData = s => anyObject.anyProperty = s;
    
            ctrl.Update();
        }
    }
