float[] testingPacket = new float[6250000];
dynamic instance = null;
foreach (var d in assembly.GetExportedTypes())
{
    instance = Activator.CreateInstance(d);
}
int L = 0;
for (int i = 0; i < L; ++i)
{
    dynamic result1 = instance.fce1(testingPacket);
    byte[] buffer = instance.fce2(result1) as byte[];
}
The higher the L is the duration period of the for cycle is closer to the duration of object casting and direct declaration using as IA<T>. Thx.
