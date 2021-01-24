    using System;
    using System.Linq;
    using System.Collections.Generic;
    namespace SO_58416947_count_bitmask_flags {
        static class Program {
    
    		[Flags]
    		public enum CheeseCharacteristics {
    			Yellow = 1,
    			Stinky = 2,
    			Squeaky = 4,
    			Holey = 8,
    			Mouldy = 16,
    			Spreadable = 32,
    			UseOnToast = Yellow | Spreadable
    		}
    
    
            static void Main(string[] args) {
    			List<CheeseCharacteristics> _testCases = new List<CheeseCharacteristics>() {
    				{CheeseCharacteristics.UseOnToast | CheeseCharacteristics.Stinky},
    				{CheeseCharacteristics.Yellow | CheeseCharacteristics.Holey},	//	Swiss
    				{CheeseCharacteristics.Squeaky},
    				{CheeseCharacteristics.Mouldy | CheeseCharacteristics.Spreadable}
    			};
    			
    			List<CheeseCharacteristics> cases = _testCases.OrderByFlagCount();
    
    			foreach(CheeseCharacteristics c in cases) {
    				Console.WriteLine($"{c}");
    			}
    		}	//	Main()
    
    
    
    		private static List<T> GetIndividualFlagValues<T>() where T:Enum {
    			Type enumType = typeof(T);
    
    			if (!enumType.IsEnum) { throw new ArgumentException("Must pass an enum type."); }
    
    			List<T> result = new List<T>();
    
    			foreach(T item in Enum.GetValues(enumType)) {
    				result.Add(item);
    			}
    
    			return result;
    		}   //	GetIndividualFlagValues()
    
    
    
    		//extension method
    		public static List<T> OrderByFlagCount<T>(this List<T> list) where T:Enum {
    			List<T> flags = GetIndividualFlagValues<T>();
    			List<T> results = list
    				.OrderBy(t => flags.Where(f => true == t.HasFlag(f)).Count())
    				.ToList();
    
    			return results;
    		}
    
        }	//	Program
    }		//	ns
