    using System;
    using System.Diagnostics;
    using System.IO;
    
    namespace HQ.Util.General.IO
    {
    	public class DirectoryRemoverRecursive
    	{
    		private readonly Action<string, string, int> _pathStatus;
    		private readonly Func<string, bool> _callbackCanRemoveFile;
    		private readonly Func<string, bool> _callbackCanRemoveFolder;
    		private Func<bool> _shouldCancel;
    
    		public int Count { get; private set; } = 0;
    
    		/// <summary>
    		/// 
    		/// </summary>
    		/// <param name="pathStatus">Arguments are [path] and [null on success or exception message]</param>
    		/// <param name="callbackCanRemoveFile">Argument is path and should return true to delete. If this function is null, all path will be deleted.</param>
    		/// <param name="callbackCanRemoveFolder">Argument is path and should return true to delete. If this function is null, all path will be deleted.</param>
    		/// <param name="shouldCancel">If null will never cancel. Cancel when func return true</param>
    		public DirectoryRemoverRecursive(
    			Action<string, string, int> pathStatus = null, 
    			Func<string, bool> callbackCanRemoveFile = null, 
    			Func<string, bool> callbackCanRemoveFolder = null, 
    			Func<bool> shouldCancel = null)
    		{
    			_pathStatus = pathStatus;
    			_callbackCanRemoveFile = callbackCanRemoveFile;
    			_callbackCanRemoveFolder = callbackCanRemoveFolder;
    			_shouldCancel = shouldCancel;
    		}
    
    		// ******************************************************************
    		/// <summary>
    		/// return true if canceled
    		/// </summary>
    		/// <param name="path"></param>
    		/// <returns></returns>
    		public bool Remove(string path)
    		{
    			string result = null;
    
    			if (path.Length < 2 || !path.StartsWith(@"\\"))
    			{
    				path = @"\\?\" + path;
    			}
    
    			if (Directory.Exists(path))
    			{
    				foreach (var subDir in Directory.GetDirectories(path))
    				{
    					if (_shouldCancel != null)
    					{
    						if (_shouldCancel())
    						{
    							return true;
    						}
    					}
    
    					if (Remove(subDir))
    					{
    						return true;
    					}
    				}
    
    				foreach (var filename in Directory.GetFiles(path))
    				{
    					if (_shouldCancel != null)
    					{
    						if (_shouldCancel())
    						{
    							return true;
    						}
    					}
    
    					if (Remove(filename))
    					{
    						return true;
    					}
    				}
    
    				try
    				{
    					if (_callbackCanRemoveFolder != null)
    					{
    						if (!_callbackCanRemoveFolder(path))
    						{
    							return false;
    						}
    					}
    
    					Directory.Delete(path);
    					Count++;
    					result = null;
    				}
    				catch (Exception ex)
    				{
    					try
    					{
    						File.SetAttributes(path, FileAttributes.Normal);
    						Directory.Delete(path);
    						Count++;
    						result = null;
    					}
    					catch (Exception)
    					{
    						result = "Try to delete directory exception: " + ex.ToString();
    					}
    				}
    			}
    			else
    			{
    				try
    				{
    					if (File.Exists(path))
    					{
    						if (_callbackCanRemoveFile != null)
    						{
    							if (!_callbackCanRemoveFile(path))
    							{
    								return false;
    							}
    						}
    
    						File.Delete(path);
    						Count++;
    						result = null;
    					}
    					else
    					{
    						Debug.Print($"File does not exists {path}");
    					}
    				}
    				catch (Exception ex)
    				{
    					try
    					{
    						File.SetAttributes(path, FileAttributes.Normal);
    						File.Delete(path);
    						Count++;
    						result = null;
    					}
    					catch (Exception)
    					{
    						result = "Try to delete file exception: " + ex.ToString();
    					}
    				}
    			}
    
    			_pathStatus?.Invoke(path, result, Count);
    
    			return false;
    		}
    
    		// ******************************************************************
    
    	}
    
    }
