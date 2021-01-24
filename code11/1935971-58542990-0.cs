interface Isa
{
    void m1();
}
interface Isb
{
    void m3();
}
interface Ia : Isa
{
    void m2();
}
interface Ib : Isb
{
    void m4();
}
class c1 : Isa, Isb
{
   
}
This way,  you achieve exactly what you want and maintain the structure of interfaces `Ia` and `Ib`. Keep in mind that this is an example and blindly applying segregation and inheritance quickly becomes a software design anti-pattern. Its use must be justified and planed for with care.
