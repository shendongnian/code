    public class Holder<T> where T: class
    {
       public T Value { get; set; }
    }
    public Task<Holder<TraumMessage>> Get() {
      var invokeTask = Invoke("GET");
      var result = invokeTask.ContinueWith<Holder<TraumMessage>>(t1 => {
        var holder = new Holder<TraumMessage>();
        var memorizeTask = t1.Result.Memorize();
        memorizeTask.ContinueWith(t2 => {
          holder.Value = t2.Result;
        }, TaskContinuationOptions.AttachedToParent);
        return holder;
      });
      return result;
    }
