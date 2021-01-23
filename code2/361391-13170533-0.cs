	using System;
	namespace Utility
	{
		/// <summary>
		/// A helper class for try-catch-related functionality
		/// </summary>
		public static class TryHelper
		{
			/// <summary>
			/// Runs each function in sequence until one throws no exceptions;
			/// if every provided function fails, the exception thrown by
			/// the final one is left unhandled
			/// </summary>
			public static void TryUntilSuccessful( params Action[] functions )
			{
				Exception exception	= null;
				foreach( Action function in functions )
				{
					try
					{
						function();
						return;
					}
					catch( Exception e )
					{
						exception	= e;
					}
				}
		
				throw exception;
			}
		}
	}
