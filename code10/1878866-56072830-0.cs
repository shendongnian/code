    public ActionResult SetQueueInfo(MyData data)
    {
        Queue<MyData> queue = null;
        if (Application["Queue"] != null)
        {
           queue = Application["Queue"] as Queue<MyData>;
        }
        else
        {
           queue = new Queue<MyData>();
        }
        queue.Enqueue(data);
        Application["Queue"] = queue;
        //other task you wanna do
    }
 
    public ActionResult BtnNext()
    {
        var queue = Application["Queue"] as Queue<MyData>
        
        if(queue != null)
        {
            var first = queue.Dequeue();
        }
        
        return RedirectToAction("Index");
    }
