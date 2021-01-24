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
