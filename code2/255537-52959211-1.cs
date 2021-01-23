	using System;
	using System.Collections.Generic;
	using System.Linq;
	enum MouseEvent { NotPressed, Clicked, Held, Released }
	public class Program {
		public static void Main() {
			// Example: Sampling the boolean state of a mouse button
			List<bool> mouseStates = new List<bool> { false, false, false, false, true, true, true, false, true, false, false, true };
			mouseStates.Zip(mouseStates.Skip(1), (oldMouseState, newMouseState) => {
				if (oldMouseState) {
					if (newMouseState) return MouseEvent.Held;
					else return MouseEvent.Released;
				} else {
					if (newMouseState) return MouseEvent.Clicked;
					else return MouseEvent.NotPressed;
				}
			})
			.ToList()
			.ForEach(mouseEvent => Console.WriteLine(mouseEvent) );
		}
	}
