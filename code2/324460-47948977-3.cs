		using System;
		namespace VariadicGenerics {
			public interface INode {
				INode Next {
					get;
				}
			}
			public interface INode<R>:INode {
				R Value {
					get; set;
				}
			}
			public abstract class Tparams {
				public static C<TValue> V<TValue>(TValue x) {
					return new T<TValue>(x);
				}
			}
			public class T<P>:C<P> {
				public T(P x) : base(x) {
				}
			}
			public abstract class C<R>:Tparams, INode<R> {
				public class T<P>:C<T<P>>, INode<P> {
					public T(C<R> node, P x) {
						if(node is R) {
							Next=(R)(node as object);
						}
						else {
							Next=(node as INode<R>).Value;
						}
						Value=x;
					}
					public T() {
						if(Extensions.TypeIs(typeof(R), typeof(C<>.T<>))) {
							Next=(R)Activator.CreateInstance(typeof(R));
						}
					}
					public R Next {
						private set;
						get;
					}
					public P Value {
						get; set;
					}
					INode INode.Next {
						get {
							return this.Next as INode;
						}
					}
				}
				public new T<TValue> V<TValue>(TValue x) {
					return new T<TValue>(this, x);
				}
				public int GetLength() {
					return m_expandedArguments.Length;
				}
				public C(R x) {
					(this as INode<R>).Value=x;
				}
				C() {
				}
				static C() {
					m_expandedArguments=Extensions.GetExpandedGenericArguments(typeof(R));
				}
				// demonstration of of non-recursive traversal
				public INode this[int index] {
					get {
						var count = m_expandedArguments.Length;
						for(INode node = this; null!=node; node=node.Next) {
							if(--count==index) {
								return node;
							}
						}
						throw new ArgumentOutOfRangeException("index");
					}
				}
				R INode<R>.Value {
					get; set;
				}
				INode INode.Next {
					get {
						return null;
					}
				}
				static readonly Type[] m_expandedArguments;
			}
		}
