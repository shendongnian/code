public void Attack(Enemy enemyAttacking)
{
    if (enemyAttacking.Type == "OneParticularEnemy")
    {
        StartCoroutine(RunDamageOverTimeAttack());
    }
}
// This coroutine starts a second coroutine that applies damage over time, it
// then waits 15 seconds before terminating the second coroutine.
public IEnumerator RunDamageOverTimeAttack()
{
    var cr = StartCoroutine(ApplyDamageOverTime());
    yield return 15000; // in milleseconds (ms), i.e. 15000 ms is 15 seconds
    cr.IsFinished = true;
}
// This coroutine applies the damage every 3 seconds until the coroutine is finished
public IEnumerator ApplyDamageOverTime()
{
    while (true)
    {
        ApplyDamageToPlayer();
        yield return 3000;
    }
}
The code reads very close to the way you described the actual problem you're trying to solve. Now for the coroutine system...
The StartCouroutine method creates a Coroutine class instance and stores it. During the Update step of the game loop you iterate through the coroutines and update them, providing gameTime to calculate when the next step of the method should run. Each step executes the code in the routine until a yield is found OR until the method ends naturally. Once the coroutine is finished you clear them out. This logic looks something like this:
private List<Coroutine> coroutines = new List<Coroutine>();
public Coroutine StartCoroutine(IEnumerator routine)
{
    var cr = new Coroutine(routine);
    couroutines.Add(cr);
    return cr;
}
public void UpdateCoroutines(GameTime gameTime)
{
    // copied in case list is modified during coroutine updates
    var coroutinesToUpdate = coroutines.ToArray();
    foreach (coroutine in coroutinesToUpdate)
        coroutine.Update(gameTime);
    coroutines.RemoveAll(c => c.IsFinished);
}
public void Update(GameTime gameTime)
{
    // normal update logic that would invoke Attack(), then...
    UpdateCoroutines(gameTime);
}
A Coroutine class is responsible for tracking the time remaining between steps of the routine, and tracking when the routine is finished. It looks something like this:
public class Coroutine
{
    private IEnumerator routine;
    private int? wait;
    public Coroutine(IEnumerator routine)
    {
        this.routine = routine;
    }
    public bool IsFinished { get; set; }
    public void Update(GameTime gameTime)
    {
        if (IsFinished) return;
        if (wait.HasValue)
        {
            var timeRemaining = wait.Value - gameTime.ElapsedGameTime.TotalMilliseconds;
            wait = timeRemaining < 0 ? null : timeRemaining;
        }
        if (!routine.MoveNext())
        {
            IsFinished= true;
        }
        else
        {
            wait = routine.Current as int?;
        }
    }
}
This may seem considerably more complex than other solutions provided here, and it may be overkill. But Coroutines allow you to forgo tracking a bunch of state in tracking variables, making complex scenarios easier to follow and cleaner to read. For example, here's a arrow spawning strategy I used Coroutines for in Ludum Dare 37. It spawns 3 arrows 600 milleseconds apart with a 3 second wait between them: https://github.com/srakowski/LD37/blob/477cf515d599eba7c4b55c3f57952865d894f741/src/LD37/GameObjects/BurstArrowSpawnBehavior.cs
Unity, one of the more popular game engines, has coroutine support. They describe scenarios where they are useful in their documentation: https://docs.unity3d.com/Manual/Coroutines.html. 
