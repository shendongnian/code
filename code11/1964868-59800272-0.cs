public Tensor Clone()
{
    Tensor tensor = new Tensor();
    tensor.MovingAverage3h = this.MovingAverage3h.ToArray();
    tensor.MovingAverage6h = this.MovingAverage6h.ToArray();
    tensor.MovingAverage1d = this.MovingAverage1d.ToArray();
    return tensor;
}
then change 
    Minutes30.Add(M6t);
to
    Minutes30.Add(M6t.Clone());
