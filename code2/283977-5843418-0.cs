    class ElementFromQueue
    {
         public object SensorData;
    }
    ...
    
    ElementFromQueue elem = new ElementFromQueue();
    elem.SensorData = new object();
    ...
    queue.Add(elem); //Element is in queue now
    ...
    elem.SensorData = new object(); //Update the data, simulating replace
