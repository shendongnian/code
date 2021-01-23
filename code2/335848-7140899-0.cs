    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Linq;
    using System.Collections.Generic;
     
    public class Bezier : Form
    {
    	static public void Main ()
    	{
    		Application.Run (new Bezier ());
    	}
    	
    	protected override void OnPaint (PaintEventArgs e)
    	{
    		// The input with all points
    		string CurveDataString = "5.47 93.75 123.22 93.75 240.97 93.75 351.22 177.75 236.47 177.75 121.72 177.75";
    		
    		string[] CurveDataStringParts = CurveDataString.Split(' ');
    		
    		int[] Keep = {2, 3, 4, 5, 6, 7, 8, 9};
    		float[] CurveData = (from i in Keep select float.Parse(CurveDataStringParts[i])).ToArray();
    		
    		e.Graphics.DrawBezier(Pens.Black, CurveData[0], CurveData[1], CurveData[2], CurveData[3],
    										  CurveData[4], CurveData[5], CurveData[6], CurveData[7]);
    		
    		for(int i = 0; i < CurveData.Length; i += 2)
    		{
    			e.Graphics.FillEllipse(Brushes.Black, new RectangleF(CurveData[i] - 2, CurveData[i + 1] - 2, 4, 4));
    		}
    		
    		base.OnPaint (e);
    	}
    }
