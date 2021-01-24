public static IEnumerable<TType> GetComponentsInCircle<TType>(Transform srcTransform, float checkRadius, LayerMask checkLayers)
{
    Collider2D[] colliders = Physics2D.OverlapCircleAll(srcTransform.position, checkRadius, checkLayers);
    IEnumerable<TType> collidersWithComponent = colliders.Select(collider => collider.gameObject.GetComponent<TType>()).Where(component=>component != null);
    return collidersWithComponent;
}
and in Update:
private void Update()
{
    var enemies = GetComponentsInCircle<EnemyProperties>(this.transform, checkRadius, checkMask);
    var hookableEnemies = enemies.Where(enemy => enemy.hookable)
    for (var enemy in hookableEnemies) {
        ...
    }
}
As a remark to your additional comment, Linq is already pretty generic and general purpose. If you learn to use it, you can set up simple filters like this in no time. And it works well with compile time types. If you want to do the same thing without compile time knowledge of the types you will have to use reflection.
Reflection is usually slow, and not easy to follow, so if you can stick to Linq and generics, you will probably do a lot better.
