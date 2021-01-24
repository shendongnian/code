	private struct ReadFileAsyncStateMachine : IAsyncStateMachine
	{
		public int _state;
		public AsyncTaskMethodBuilder<string> _builder;
		private string _fileName;
		private string _fileText;
		private StreamReader _reader;
		TaskAwaiter<string> _awaiter;
		void IAsyncStateMachine.MoveNext()
		{
			try
			{
				if (_state != 0)
				{
					goto afterSetup;
				}
	
				_fileName = GenerateFileName();
				_reader = File.OpenText(_fileName);
				TaskAwaiter<string> awaiter = _reader.ReadToEndAsync().GetAwaiter();
				_state = -1;
				if (!awaiter.IsCompleted)
				{
					_awaiter = awaiter;
					_builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, ReadFileAsyncStateMachine>(ref awaiter, ref this);
					return;
				}
	
			afterSetup:
				awaiter = _awaiter;
				_fileText = awaiter.GetResult();
				_state = -2;
				_builder.SetResult(_fileName + "|" + _fileText);
                _reader.Dispose();
			}
			catch (Exception exception)
			{
				_state = -2;
				_builder.SetException(exception);
                _reader?.Dispose();
				return;
			}
		}
		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine param0)
		{
			_builder.SetStateMachine(param0);
		}
	}
	
	public Task<string> ReadFile()
	{
		ReadFileAsyncStateMachine stateMachine = new ReadFileAsyncStateMachine();
		AsyncTaskMethodBuilder<string> builder = AsyncTaskMethodBuilder<string>.Create();
		
		stateMachine._builder = builder;
		stateMachine._state = -1;
		builder.Start(ref stateMachine);
		return builder.Task;
	}
