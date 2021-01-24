 c#
static void Main(string[] args)
{
    new Program().DoTheThing();
}
void DoTheThing() // naming is hard
{
    // array "køn"
    string[] gen = { "♂", "♀" };
    // Oprettelse af vores array "PokemonList"
...
I'd probably also move the logic here *out* of the `Program` class, and just have that do the actual launch / args handling, so:
 c#
static void Main(string[] args)
{
    new PokemonWhatever().DoTheThing();
}
and move `DoTheThing` to `class PokemonWhatever` (and make it `public` or `internal`)
