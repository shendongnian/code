class A<dynamic>
{
}
var a = new A<string>();
is a generic type with one type parameter whose name is `dynamic`. Then follows an instantiation of the type where `string` is passed as a type argument to the type parameter `dynamic`. This:
class A<T>
{
}
var a = new A<dynamic>();
is a generic type with one type parameter whose name is `T`. Then follows an instantiation of the type where `dynamic` is passed as a type argument to the type parameter `T`.
You're looking for the latter, not the former.
