    public static class InvokeFunc
	{
		private class InvokeFuncImpl<TRusult>
		{
			public Func<TRusult> Func { get; }
			public InvokeFuncImpl(Func<TRusult> f)
			{
				Func = f;
			}
			public static implicit operator Func<TRusult>(InvokeFuncImpl<TRusult> value)
			{
				return () =>
				{
					if(Form.ActiveForm == null)
						return value.Func();
					if(!Form.ActiveForm.InvokeRequired)
						return value.Func();
					return (TRusult)Form.ActiveForm.Invoke(value.Func);
				};
			}
		}
		private class InvokeFuncImpl<TArg1, TRusult>
		{
			public Func<TArg1, TRusult> Func { get; }
			public InvokeFuncImpl(Func<TArg1, TRusult> f)
			{
				Func = f;
			}
			public static implicit operator Func<TArg1, TRusult>(InvokeFuncImpl<TArg1, TRusult> value)
			{
				return (arg) =>
				{
					if(Form.ActiveForm == null)
						return value.Func(arg);
					if(!Form.ActiveForm.InvokeRequired)
						return value.Func(arg);
					return (TRusult)Form.ActiveForm.Invoke(value.Func, arg);
				};
			}
		}
		public static Func<TResult> Bulid<TResult>(Func<TResult> f) => new InvokeFuncImpl<TResult>(f);
		public static Func<TArg1, TResult> Bulid<TArg1, TResult>(Func<TArg1, TResult> f) => new InvokeFuncImpl<TArg1, TResult>(f);
	}
