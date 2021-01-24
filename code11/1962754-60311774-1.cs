using System;
#nullable enable
namespace ErrorHandling {
  public interface IResult<TSuccess, TError> {
    public bool OK { get; }
    public TSuccess Data => (this is Ok<TSuccess, TError>(var Data)) ? Data : throw new InvalidOperationException("An Error has no data");
    public TError Error => (this is Fail<TSuccess, TError>(var Error)) ? Error : throw new InvalidOperationException("A Success Result has no Description");
    public static IResult<TSuccess, TError> Good(TSuccess data) => new Ok<TSuccess, TError>(data);
    public static IResult<TSuccess, TError> Bad(TError error) => new Fail<TSuccess, TError>(error);
  }
  public class Ok<TSuccess, TError> : IResult<TSuccess, TError> {
    public bool OK => true;
    public TSuccess Data { get; }
    public Ok(TSuccess data) => Data = data;
    public void Deconstruct(out TSuccess data) => data = Data;
  }
  public class Fail<TSuccess, TError> : IResult<TSuccess, TError> {
    public bool OK => false;
    public TError Error { get; }
    public Fail(TError error) => Error = error;
    public void Deconstruct(out TError error) => error = Error;
  }
  class Main {
    public IResult<int, string> F() {
      if (DateTime.Now.Year < 2020) return IResult<int, string>.Good(3);
      return IResult<int, string>.Bad("error");
    }
    public void F1() {
      var message = F() switch { 
        { OK: true, Data: var data } => $"Got some: {data}",
        { OK: false, Error: var error } => $"Oops {error}",
      };
      Console.WriteLine(message);
    }
    public void F2() {
      if (F() is { OK: false, Error: var error }) {
        Console.WriteLine(error);
        return;
      }
      if (F() is { OK: true, Data: var data }) { // Is there a way to get data without a new scope ?
        Console.WriteLine(data);
      }
    }
  }
}
