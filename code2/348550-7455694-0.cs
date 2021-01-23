    using System;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApplication23 {
      public class Program {
        public static void Main() {
          const int repeatCount=20;
          const int arraySize=5000000;
    
          var values=MakeValues(arraySize);
    
          for(var pass=0; pass<2; ++pass) {
            Console.WriteLine("Starting old");
            var startOld=DateTime.Now;
            for(var i=0; i<repeatCount; ++i) {
              var result=TransformOld(values);
            }
            var elapsedOld=DateTime.Now-startOld;
    
            Console.WriteLine("Starting new");
            var startNew=DateTime.Now;
            for(var i=0; i<repeatCount; ++i) {
              var result=TransformNew(values);
            }
            var elapsedNew=DateTime.Now-startNew;
    
            var difference=elapsedOld-elapsedNew;
            var percentage=(double)difference.TotalMilliseconds/elapsedOld.TotalMilliseconds;
    
            Console.WriteLine("pass {0}: old {1} new {2} percent {3}", pass, elapsedOld, elapsedNew, percentage);
          }
          Console.Write("Press enter: ");
          Console.ReadLine();
        }
    
        private static float4x4[] MakeValues(int count) {
          var result=new float4x4[count];
          for(var i=0; i<count; ++i) {
            result[i]=new float4x4(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
          }
          return result;
        }
    
        public static float[] TransformOld(float4x4[] value) {
          var array=new float[value.Length*16];
          int n = 0;
          for(int i = 0; i < value.Length; i++) {
            array[n++] = value[i].M11;
            array[n++] = value[i].M12;
            array[n++] = value[i].M13;
            array[n++] = value[i].M14;
    
            array[n++] = value[i].M21;
            array[n++] = value[i].M22;
            array[n++] = value[i].M23;
            array[n++] = value[i].M24;
    
            array[n++] = value[i].M31;
            array[n++] = value[i].M32;
            array[n++] = value[i].M33;
            array[n++] = value[i].M34;
    
            array[n++] = value[i].M41;
            array[n++] = value[i].M42;
            array[n++] = value[i].M43;
            array[n++] = value[i].M44;
          }
          return array;
        }
    
        public static unsafe float[] TransformNew(float4x4[] values) {
          var array=new float[values.Length*16];
          fixed(float* arrayStart=array) {
            var destp=arrayStart;
            fixed(float4x4* valuesStart=values) {
              int count=values.Length;
              for(var valuesp=valuesStart; count>0; ++valuesp, --count) {
                var sourcep=valuesp->data;
                for(var i=0; i<16/4; ++i) {
                  *destp++=*sourcep++;
                  *destp++=*sourcep++;
                  *destp++=*sourcep++;
                  *destp++=*sourcep++;
                }
              }
            }
            return array;
          }
        }
    
        [StructLayout(LayoutKind.Explicit)]
        public unsafe struct float4x4 {
          [FieldOffset(0)] public float M11;
          [FieldOffset(4)] public float M12;
          [FieldOffset(8)] public float M13;
          [FieldOffset(12)] public float M14;
          [FieldOffset(16)] public float M21;
          [FieldOffset(20)] public float M22;
          [FieldOffset(24)] public float M23;
          [FieldOffset(28)] public float M24;
          [FieldOffset(32)] public float M31;
          [FieldOffset(36)] public float M32;
          [FieldOffset(40)] public float M33;
          [FieldOffset(44)] public float M34;
          [FieldOffset(48)] public float M41;
          [FieldOffset(52)] public float M42;
          [FieldOffset(56)] public float M43;
          [FieldOffset(60)] public float M44;
    
          //notice the use of "fixed" keyword to make the array inline
          //and the use of the FieldOffset attribute to overlay that inline array on top of the other fields
          [FieldOffset(0)] public fixed float data[16];
    
          public float4x4(float m11, float m12, float m13, float m14,
            float m21, float m22, float m23, float m24,
            float m31, float m32, float m33, float m34,
            float m41, float m42, float m43, float m44) {
            M11=m11; M12=m12; M13=m13; M14=m14;
            M21=m21; M22=m22; M23=m23; M24=m24;
            M31=m31; M32=m32; M33=m33; M34=m34;
            M41=m41; M42=m42; M43=m43; M44=m44;
          }
        }
      }
    }
    
