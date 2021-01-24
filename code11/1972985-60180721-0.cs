public Vector3 Sample(System.Func<Vector3, Vector3> funcOne, Vector3 samplePoint)
{
    var b = funcOne(samplePoint);
    return b;
}
public Vector3 Trace(Vector3 point)
{
    // Even more vector operations, as follows
    Vector3 k1 = Sample(FunctionOne, point);
    // (...)
    return k1;
}
