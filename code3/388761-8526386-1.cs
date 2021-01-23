        public class SurfaceCalculator
        {
        private ValueXyz[] _valuesXyz;
        private double _surface;
        private readonly string _textWithValues;
        public SurfaceCalculator(string textWithValues)
        {
            _textWithValues = textWithValues;
            SetValuesToCalculate();
        }
        public double Surface
        {
            get { return _surface; }
        }
        public void CalculateSurface()
        {
            for (var i = 0; i < _valuesXyz.Length; i++)
            {
                if (_valuesXyz[i].Z == 0)
                    _surface = (_valuesXyz[i].X*_valuesXyz[i + 1].Y) - (_valuesXyz[i + 1].X*_valuesXyz[i].Y);
            }
        }
        private void SetValuesToCalculate()
        {
            var valuesXyz = _textWithValues.Split(' '); 
            _valuesXyz = valuesXyz.Select(item => new ValueXyz
                                                      {
                                                          X = Convert.ToDouble(item.Split(',')[0]),
                                                          Y = Convert.ToDouble(item.Split(',')[1]),
                                                          Z = Convert.ToInt32(item.Split(',')[2])
                                                      }).ToArray();
        }
    }
