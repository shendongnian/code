    using System;
    using System.Linq;
    
    namespace StackOverflow
    {
        internal class StackOverflowTest
        {
            private static void Main()
            {
                string sInt = UniformInt.GlslType;
                string sDouble = UniformDouble.GlslType;
            }
        }
    
        public abstract class Uniform<B, T> // Curiously recurring template pattern 
            where B : Uniform<B, T>
        {
            public static string GlslType
            {
                get
                {
                    var attribute = typeof(B).GetCustomAttributes(typeof(GlslTypeAttribute), true);
    
                    if (!attribute.Any())
                    {
                        throw new InvalidOperationException(
                            "The GslType cannot be determined. Make sure the GslTypeAttribute is added to all derived classes.");
                    }
    
                    return ((GlslTypeAttribute)attribute[0]).GlslType;
                }
            }
        }
    
        [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
        internal sealed class GlslTypeAttribute : Attribute
        {
            public string GlslType { get; private set; }
    
            public GlslTypeAttribute(string glslType)
            {
                GlslType = glslType;
            }
        }
    
        [GlslType("int")]
        public class UniformInt : Uniform<UniformInt, int> // Curiously recurring template pattern 
        {
        }
    
        [GlslType("double")]
        public class UniformDouble : Uniform<UniformDouble, double> // Curiously recurring template pattern 
        {
        }
    }
