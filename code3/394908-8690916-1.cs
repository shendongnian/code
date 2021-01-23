	public abstract class Uniform<T>
	{
		public readonly int Location;
		public virtual T Variable
		{
			get; set;
		}
	}
	public class UniformMatrix4 : Uniform<Matrix4>
	{
		public override Matrix4 Variable
		{
			get
			{
				return base.Variable;
			}
			set
			{
				base.Variable = value;
				GL.UniformMatrix4(Location, false, ref value);
			}
		}
	}
