		using System.Diagnostics;
		using System;
		namespace VariadicGenerics {
			[DebuggerStepThrough]
			public static class Extensions {
				public static readonly Type VariadicType = typeof(C<>.T<>);
				public static bool TypeIs(this Type x, Type d) {
					if(null==d) {
						return false;
					}
					for(var c = x; null!=c; c=c.BaseType) {
						var a = c.GetInterfaces();
						for(var i = a.Length; i-->=0;) {
							var t = i<0 ? c : a[i];
							if(t==d||t.IsGenericType&&t.GetGenericTypeDefinition()==d) {
								return true;
							}
						}
					}
					return false;
				}
				public static Type[] GetExpandedGenericArguments(this Type t) {
					var expanded = new Type[] { };
					for(var skip = 1; t.TypeIs(VariadicType) ? true : skip-->0;) {
						var args = skip>0 ? t.GetGenericArguments() : new[] { t };
						if(args.Length>0) {
							var length = args.Length-skip;
							var temp = new Type[length+expanded.Length];
							Array.Copy(args, skip, temp, 0, length);
							Array.Copy(expanded, 0, temp, length, expanded.Length);
							expanded=temp;
							t=args[0];
						}
					}
					return expanded;
				}
			}
		}
