    public class Task
    {
        public int TaskId { get; set; }
        public int ParentId { get; set; }
    }
    ...
    var o = Wrapper.New(new Task() { TaskId = 1 });
    var o1 = o.Copy();
    var o2 = o1.Copy();
    ((Task) o1).TaskId = 3;
    o2.Dispose();
    o1.Dispose();
    o.Dispose();
