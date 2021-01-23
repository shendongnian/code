	public abstract class Uniform<T>
	{
		public readonly int Location;
		protected T _variable;
		public virtual T Variable
		{
			get { return _variable; }
			set { SetVariable(value); } 
		}
		protected abstract void SetVariable(T value);
	}
	public class UniformMatrix4 : Uniform<Matrix4>
	{
		public override void SetVariable(Matrix4x4 value)
		{
			_variable = value;
			GL.UniformMatrix4(Location, false, ref _variable);
		}
	}
