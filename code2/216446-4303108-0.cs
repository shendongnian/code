using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
namespace ConsoleApplication1
{
    public struct category_info 
    { 
        public int id;
        public IntPtr name;
        public IntPtr description;
    }; 
    class Program
    {
        [DllImport("mydll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr xyz_categories_info(ref IntPtr cat, ref int catSize);
        [DllImport("mydll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void xyz_categories_info_free(IntPtr cat); 
        static void Main(string[] args)
        {
            IntPtr categories = IntPtr.Zero;
            IntPtr category_buffer = IntPtr.Zero;
            int category_count = 0;
            category_info info = new category_info();
            IntPtr current;
            try
            {
                category_buffer = xyz_categories_info(ref categories, ref category_count);
                if (category_buffer == IntPtr.Zero)
                {
                    return;
                }
                if (category_count == 0)
                {
                    return;
                }
                for (int j = 0; j &lt; category_count; j++)
                {
                    if (IntPtr.Size == 4)
                    {
                        current = new IntPtr(categories.ToInt32() + j * Marshal.SizeOf(info));
                    }
                    else
                    {
                        current = new IntPtr(categories.ToInt64() + j * Marshal.SizeOf(info));
                    }
                    info = (category_info)Marshal.PtrToStructure(current, typeof(category_info));
                    if (info.id == 0)
                    {
                        continue;
                    }
                    Console.WriteLine(info.id);
                    Console.WriteLine(Marshal.PtrToStringAnsi(info.name));
                    Console.WriteLine(Marshal.PtrToStringAnsi(info.description));
                }
            }
            finally
            {
                if (category_buffer != IntPtr.Zero)
                {
                    xyz_categories_info_free(category_buffer);
                }
            }
        }
    }
}
