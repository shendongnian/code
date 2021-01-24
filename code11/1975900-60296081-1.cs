c#
//Snake Collision with its own body
for (int i = 1; i < snake.Count; i++)
{
    //if Snake equal itself then snake hasn't touch any other parts of its body
    if (snake[0].X == snake[i].X && snake[0].Y == snake[i].Y)
    {
        this.bGameOver = true;
        break;
    }
}
Note, in your code every time when the snake grows, a collision of the head with the body will be detected, because you insert a new element at the had position.  
You can get rid about set, if you just avoid to remove the tail element of the snake instead:
c#
private new void Update()
{
    // Calculate a new position of the head of the snake
    Point newHeadPosition = new Point(snake[0].X + snakeDirection.X, snake[0].Y + snakeDirection.Y);
    // Insert new position in the beginning of the snake list
    snake.Insert(0, newHeadPosition);
    # snake.RemoveAt(snake.Count - 1); <--------- DELETE    
    // Check snake collision with the food
    if (snake[0].X != mouse.X || snake[0].Y != mouse.Y)
    {
        # remove tail if snake does not grow
        snake.RemoveAt(snake.Count - 1); # <---------- ADD
        return;
    }
    else
    {
        //Snake Grow
        // snake.Add(new Point(mouse.X, mouse.Y)); <------ DELETE
    }
    Console.WriteLine();
    // Generate a new food(mouse) position
    GenerateFood();
} //Events 
