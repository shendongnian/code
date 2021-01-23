	public class Surrounding4ModificationStrategy
	{
		public bool IsMatch(IList<ColorResult> input, int index)
		{
			if (index < 2)
			{
				return false;
			}
			if (index >= input.Count - 2)
			{
				return false;
			}
			if (input[index].Probability >= 60)
			{
				return false;
			}
			var secondPrevious = input[index - 2];
			if (secondPrevious.Probability < 60)
			{
				return false;
			}
			var firstPrevious = input[index - 1];
			if (firstPrevious.Probability < 60)
			{
				return false;
			}
			var firstNext = input[index + 1];
			if (firstNext.Probability < 60)
			{
				return false;
			}
			var secondNext = input[index + 2];
			if (secondNext.Probability < 60)
			{
				return false;
			}
			if (new[] { secondPrevious.Color, firstPrevious.Color, firstNext.Color, secondNext.Color }.Distinct().Count() > 1)
			{
				return false;
			}
			return true;
		}
		public void Update(IList<ColorResult> input, int index)
		{
			input[index].Color = input[index + 1].Color;
		}
	}
