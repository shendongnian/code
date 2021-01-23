        public static void UniformMatrix4(int location, Int32 count, bool transpose, float[] value) {
			unsafe {
				fixed (float* fp_value = value)
				{
					Delegates.pglUniformMatrix4fv(location, count, transpose, fp_value);
				}
			}
		}
        [System.Runtime.InteropServices.DllImport(Library, EntryPoint = "glUniformMatrix4fv", ExactSpelling = true)]
		internal extern static unsafe void glUniformMatrix4fv(int location, Int32 count, bool transpose, float* value);
