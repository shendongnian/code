public static IEnumerable<TType> GetComponentsWithAttributeInCircle<TType>(Transform srcTransform, float checkRadius, LayerMask checkLayers, Func<TType, bool> filter)
{
    Collider2D[] colliders = Physics2D.OverlapCircleAll(srcTransform.position, checkRadius, checkLayers);
    IEnumerable<TType> colliderWithComponentAttribute = colliders.Select(collider => collider.gameObject.GetComponent<TType>()).Where(component => component != null).Where(filter);
    return colliderWithComponentAttribute;
}
and in Update:
private void Update()
{
    var hookableEnemies = Sense.GetComponentsWithAttributeInCircle<EnemyProperties>(this.transform, checkRadius, checkMask, (EnemyProperties => EnemyProperties.hookable));
    foreach (var enemy in hookableEnemies)
    {
        ...
    }
}
As a remark to your additional comment, Linq is already pretty generic and general purpose. If you learn to use it, you can set up simple filters like this in no time. And it works well with compile time types. If you want to do the same thing without compile time knowledge of the types you will have to use reflection.
Reflection is usually slow, and not easy to follow, so if you can stick to Linq and generics, you will probably do a lot better.
