    int[] gpos = new int[] { gxpos, gypos, gzpos };
    int[] pos = new int[] { xpos, ypos, zpos };
    int[] mpos = new int[] { mxpos, mypos, mzpos };
    string axisNames = new string[] { "x", "y", "z" };
    public void moove(int axis)
    {
        gpos[axis] = pos[axis] + trkSizeStep.Value;
        if (gpos[axis] != mpos[axis] || -gpos[axis] != mpos[axis])
        {
            pos[axis] = gpos[axis];
            port.WriteLine(axisNames[axis] + pos[axis]);
            lblpos[axis].Text = pos[axis].ToString();
        }
        else
        {
            errorLimit(axisNames[axis], 1);
        }
    }
