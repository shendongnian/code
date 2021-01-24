	using System;
	using System.Runtime.InteropServices;
	namespace MainProgram {
		class MainClass {
			static void Main(string[] args) {
				int fbfd = -1;  // file descriptor for framebuffer device
				int fbp = -1;   // pointer to mapped framebuffer memory
				uint fbs = 0;   // size of mapped framebuffer memory
				int result = 0; // utility result variable
				try {
				// Initialize (not sure if this is needed, but...).
				Libc.bcm_host_init();
				// Open the device.  (Command line param is device, e.g. "/dev/fb0" or "/dev/fb1".)
				fbfd = Libc.open(args[0], Libc.O_RDWR);
				if (fbfd == -1)
					throw new Exception("open: result=" + fbfd + ", error=" + Marshal.GetLastWin32Error());
				Console.WriteLine("fbfd=" + fbfd);
				// Get fixed screen info.
				Libc.fb_fix_screeninfo fixInfo = new Libc.fb_fix_screeninfo();
				result = Libc.ioctl1(fbfd, Libc.FBIOGET_FSCREENINFO, ref fixInfo);
				if (result == -1)
					throw new Exception("ioctl1: result=" + result + ", error " + Marshal.GetLastWin32Error());
				Console.WriteLine("fbfix: mem start=" + fixInfo.smem_start.ToString("X8") + ", len=" + fixInfo.smem_len);
				// Get variable screen info.
				Libc.fb_var_screeninfo varInfo = new Libc.fb_var_screeninfo();
				result = Libc.ioctl2(fbfd, Libc.FBIOGET_VSCREENINFO, ref varInfo);
				if (result == -1)
					throw new Exception("ioctl2: result=" + result + ", error " + Marshal.GetLastWin32Error());
				Console.WriteLine("fbvar: res=" + varInfo.xres + "x" + varInfo.yres + ", bpp=" + varInfo.bits_per_pixel);
				// Map framebuffer memory to virtual space.
				fbp = Libc.mmap(0, fixInfo.smem_len, Libc.PROT_READ | Libc.PROT_WRITE, Libc.MAP_SHARED, fbfd, 0);
				if (fbp == Libc.MAP_FAILED)
					throw new Exception("mmap: result=" + fbp + ", error " + Marshal.GetLastWin32Error());
				Console.WriteLine("mmap: location=" + fbp.ToString("X8"));
				}
				catch (Exception ex) {
					Console.WriteLine("*** Error: " + ex.Message);
				}
				finally {
					if (fbp != -1)
						result = Libc.munmap(fbp, fbs);
					if (fbfd != -1)
						result = Libc.close(fbfd);
				};
			}
			public static class Libc {
				public const int O_RDWR = 0x0002;
				public const int PROT_READ = 0x1;
				public const int PROT_WRITE = 0x2;
				public const int MAP_SHARED = 0x01;
				public const int MAP_FAILED = -1;
				public const int FBIOGET_VSCREENINFO = 0x4600;
				public const int FBIOGET_FSCREENINFO = 0x4602;
				[DllImport("libbcm_host.so", EntryPoint = "bcm_host_init")]
				public static extern void bcm_host_init();
				[DllImport("libc", EntryPoint="open", SetLastError = true)]
				public static extern int open(
					[MarshalAs(UnmanagedType.LPStr)] string filename,
					[MarshalAs(UnmanagedType.I4)] int flags
				);
				[DllImport("libc", EntryPoint="close", SetLastError = true)]
				public static extern int close(
					[MarshalAs(UnmanagedType.I4)] int filedes
				);
				[DllImport("libc", EntryPoint="ioctl", SetLastError = true)]
				public static extern int ioctl1(
					[MarshalAs(UnmanagedType.I4)] int filedes,
					[MarshalAs(UnmanagedType.I4)] int command,
					ref fb_fix_screeninfo data
				);
				[DllImport("libc", EntryPoint="ioctl", SetLastError = true)]
				public static extern int ioctl2(
					[MarshalAs(UnmanagedType.I4)] int filedes,
					[MarshalAs(UnmanagedType.I4)] int command,
					ref fb_var_screeninfo data
				);
				[DllImport("libc", EntryPoint = "mmap", SetLastError = true)]
				public static extern int mmap(
					[MarshalAs(UnmanagedType.U4)] uint addr,
					[MarshalAs(UnmanagedType.U4)] uint length,
					[MarshalAs(UnmanagedType.I4)] int prot,
					[MarshalAs(UnmanagedType.I4)] int flags,
					[MarshalAs(UnmanagedType.I4)] int fdes,
					[MarshalAs(UnmanagedType.I4)] int offset
				);
				[DllImport("libc", EntryPoint = "munmap", SetLastError = true)]
				public static extern int munmap(
					[MarshalAs(UnmanagedType.I4)] int addr,
					[MarshalAs(UnmanagedType.U4)] uint length
				);
				[StructLayout(LayoutKind.Sequential)]
				public struct fb_fix_screeninfo {
					[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)] public byte[] id;
					[MarshalAs(UnmanagedType.U4)] public uint smem_start;
					[MarshalAs(UnmanagedType.U4)] public uint smem_len;
					[MarshalAs(UnmanagedType.U4)] public uint type;
					[MarshalAs(UnmanagedType.ByValArray, SizeConst = 36)] public byte[] stuff;
				};
				[StructLayout(LayoutKind.Sequential)]
				public struct fb_var_screeninfo {
					[MarshalAs(UnmanagedType.U4)] public uint xres;
					[MarshalAs(UnmanagedType.U4)] public uint yres;
					[MarshalAs(UnmanagedType.U4)] public uint xres_virtual;
					[MarshalAs(UnmanagedType.U4)] public uint yres_virtual;
					[MarshalAs(UnmanagedType.U4)] public uint xoffset;
					[MarshalAs(UnmanagedType.U4)] public uint yoffset;
					[MarshalAs(UnmanagedType.U4)] public uint bits_per_pixel;
					[MarshalAs(UnmanagedType.ByValArray, SizeConst = 132)] public byte[] stuff;
				};
			}
		}
	}
