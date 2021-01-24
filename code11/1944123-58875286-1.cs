    //contact with right paddle
            else if (ball.Bounds.IntersectsWith(paddle2.Bounds))
            {
                double paddle2_locationvar = paddle2.Top;
                paddle2_Bounds_text.Text = paddle2_locationvar.ToString() + " " + ball.Top.ToString();
                double ball_locationvar = ball.Top;
                double zonevar = ball_locationvar - paddle2_locationvar;
                paddle2_Bounds_text.Text = zonevar.ToString();
                timer5.Stop();
                //zones
                if (zonevar <= 12.571)
                {
                    ballx = ballx * -1;
                    bally = 6;
                    timer5.Start();
                }
                else if (zonevar > 12.571 && zonevar <= 25.142)
                {
                    ballx = ballx * -1;
                    bally = 4;
                    timer5.Start();
                }
                else if (zonevar > 25.142 && zonevar <= 37.713)
                {
                    ballx = ballx * -1;
                    bally = 2;
                    timer5.Start();
                }
                else if (zonevar > 37.713 && zonevar <= 50.284)
                {
                    ballx = ballx * -1;
                    bally = 0;
                    timer5.Start();
                }
                else if (zonevar > 50.284 && zonevar <= 62.855)
                {
                    ballx = ballx * -1;
                    bally = -2;
                    timer5.Start();
                }
                else if (zonevar > 62.855 && zonevar <= 75.426)
                {
                    ballx = ballx * -1;
                    bally = -4;
                    timer5.Start();
                }
                else if (zonevar > 75.426 && zonevar <= 88)
                {
                    ballx = ballx * -1;
                    bally = -6;
                    timer5.Start();
                }
                else
                    ballx = ballx * -1;
