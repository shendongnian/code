	public interface IKing<T> where T:Result{
	  public T Get();
	}
	public ResultA KingA:King<ResultA>{
	   return new ResultA;
	}
	public ResultB KingB:King<ResultB>{
	   return new ResultB
	}
