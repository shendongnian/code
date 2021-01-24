	using System;
	using System.Timers;
	using System.Drawing;
	public class Program
	{
		static int stepCount = 0;
		static int numberOfSteps = 0;
		static float stepDistanceX = 0;
		static float stepDistanceY = 0;
		static PointF destinationPoint;
		static Timer timer;
		public static void Main()	
		{
			int timerStepDurationMs = 1000 / 125;
			PointF currentPoint = Cursor.Position;
			destinationPoint = new PointF(2000, 1800); // or however you select your point
			
			int movementDurationMs = new Random().Next(900, 1100); // roughly 1 second
			int numberOfSteps = movementDurationMs / timerStepDurationMs;
			stepDistanceX = (destinationPoint.X - currentPoint.X) / (float)numberOfSteps;
			stepDistanceY = (destinationPoint.Y - currentPoint.Y) / (float)numberOfSteps;
			timer = new Timer(timerStepDurationMs);
			timer.Elapsed += MoveMouse;
			timer.Start();
			while (stepCount != numberOfSteps) { }
		}
		static void MoveMouse(object sender, ElapsedEventArgs e)
		{
			stepCount++;
			if (stepCount == numberOfSteps)
			{
				Cursor.Position = destinationPoint;
				timer.Stop();
			}
			Cursor.Position.X += stepDistanceX;
			Cursor.Position.Y += stepDistanceY;
		}
	}
