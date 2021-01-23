    void Main() {
        var objectA = GetObjectA();
        objectA.DoMyTask();
    }
    
    GetObjectA(){
        return If_All_Is_Well ? new ObjectA() : new EmptyObjectA();
    }
    
    class ObjectA() {
        DoMyTask() {
            var objectB = GetObjectB();
            var objectC = GetObjectC();
            objectC.DoAnotherTask();     // I am assuming that you would call the doXXX or doYYY methods on objectB or C because otherwise there is no need to create them
        }
        void GetObjectC() {
            return If_All_Is_Well_Again ? new ObjectC() : new EmptyObjectC();
        }
    }
    
    class EmptyObjectA() { // http://en.wikipedia.org/wiki/Null_Object_pattern
        DoMyTask() {
            doZZZZ();
        }
    }
    class ObjectC() {
        DoAnotherTask() {
            doXXX();
        }
    }
    class EmptyObjectB() { 
        DoAnotherTask() {
            doYYY();
        }
    }
