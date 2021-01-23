                // cell.SegmentedControl for me was a UISegmented control in a UITableViewCell
                cell.SegmentedControl.ValueChanged += (s, e) =>
                {
                    OptionalSegmentedControl osc = (OptionalSegmentedControl)s;
                   // continue with your code logic.....
                };
