    using System.Numerics.Tensors;
    ..
    var src = new byte[3, w, h]
    var dst = ArrayTensorExtensions
        .ToTensor(src)
        .Reshape(new[] { 3, w * h });
