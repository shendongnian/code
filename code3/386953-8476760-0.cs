    static void Main(string[] args)
    {
    //enqueue parent links here
    ...
    //then start crawling via threading
    ...
    }
    public void X()
    {
        //block the threads until all of them are here
    }
    public void Crawl(Action x)
    {
        //dequeue
        //get child links
        //enqueue child links
        //call x()
    }
