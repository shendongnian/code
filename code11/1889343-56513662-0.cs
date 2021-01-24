public sealed class ActionResult<TValue> : IConvertToActionResult
{
       public TValue Value { get; }
       public ActionResult(TValue value)
       {
            /* error checking code removed */
            Value = value;
       }
       public static implicit operator ActionResult<TValue>(TValue value)
       {
           return new ActionResult<TValue>(value);
       }
}
`public static implicit operator` I.e. this method provides the logic for `TValue` to be **implicitly** casted to type ActionResult<TValue>. It's a very simple method that creates a new `ActionResult` with the value set to a public variable called `Value`. This method makes this legal:
ActionResult<int> result = 10; <-- // same as new ActionResult(10)
This essentially creates syntatic sugar for what you do in the Action methods to be legal.
  [1]: https://github.com/aspnet/AspNetCore/blob/master/src/Mvc/Mvc.Core/src/ActionResultOfT.cs
